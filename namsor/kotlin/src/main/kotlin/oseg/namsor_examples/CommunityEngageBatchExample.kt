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
class CommunityEngageBatchExample
{
    fun communityEngageBatch()
    {
        ApiClient.apiKey["X-API-KEY"] = "YOUR_API_KEY"

        val personalNames1 = FirstLastNameGeoIn(
            id = "id",
            firstName = "firstName",
            lastName = "lastName",
            countryIso2 = "countryIso2",
        )

        val personalNames2 = FirstLastNameGeoIn(
            id = "id",
            firstName = "firstName",
            lastName = "lastName",
            countryIso2 = "countryIso2",
        )

        val personalNames = arrayListOf<FirstLastNameGeoIn>(
            personalNames1,
            personalNames2,
        )

        val batchFirstLastNameGeoIn = BatchFirstLastNameGeoIn(
            personalNames = personalNames,
        )

        try
        {
            val response = PersonalApi().communityEngageBatch(
                batchFirstLastNameGeoIn = batchFirstLastNameGeoIn,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling PersonalApi#communityEngageBatch")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling PersonalApi#communityEngageBatch")
            e.printStackTrace()
        }
    }
}
