package oseg.namsor_examples

import app.namsor.client.infrastructure.*
import app.namsor.client.apis.*
import app.namsor.client.models.*

import java.io.File
import java.time.LocalDate
import java.time.OffsetDateTime
import kotlin.collections.ArrayList
import kotlin.collections.List
import kotlin.collections.Map
import com.squareup.moshi.adapter

@ExperimentalStdlibApi
class UsRaceEthnicityZIP5Example
{
    fun usRaceEthnicityZIP5()
    {
        ApiClient.apiKey["X-API-KEY"] = "YOUR_API_KEY"

        try
        {
            val response = PersonalApi().usRaceEthnicityZIP5(
                firstName = "Keith",
                lastName = "Haring",
                zip5Code = "12345",
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling PersonalApi#usRaceEthnicityZIP5")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling PersonalApi#usRaceEthnicityZIP5")
            e.printStackTrace()
        }
    }
}
