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
class GenderBatchExample
{
    fun genderBatch()
    {
        ApiClient.apiKey["X-API-KEY"] = "YOUR_API_KEY"

        val personalNames1 = FirstLastNameIn(
            id = "b590b04c-da23-4f2f-a334-aee384ee420a",
            firstName = "Keith",
            lastName = "Haring",
        )

        val personalNames = arrayListOf<FirstLastNameIn>(
            personalNames1,
        )

        val batchFirstLastNameIn = BatchFirstLastNameIn(
            personalNames = personalNames,
        )

        try
        {
            val response = PersonalApi().genderBatch(
                batchFirstLastNameIn = batchFirstLastNameIn,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling PersonalApi#genderBatch")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling PersonalApi#genderBatch")
            e.printStackTrace()
        }
    }
}
