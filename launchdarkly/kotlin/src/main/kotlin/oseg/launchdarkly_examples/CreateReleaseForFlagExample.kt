package oseg.launchdarkly_examples

import com.launchdarkly.client.infrastructure.*
import com.launchdarkly.client.apis.*
import com.launchdarkly.client.models.*

import java.io.File
import java.time.LocalDate
import java.time.OffsetDateTime
import kotlin.collections.ArrayList
import kotlin.collections.List
import kotlin.collections.Map
import com.squareup.moshi.adapter

@ExperimentalStdlibApi
class CreateReleaseForFlagExample
{
    fun createReleaseForFlag()
    {
        ApiClient.apiKey["ApiKey"] = "YOUR_API_KEY"

        val createReleaseInput = CreateReleaseInput(
            releasePipelineKey = null,
            releaseVariationId = null,
        )

        try
        {
            val response = ReleasesBetaApi().createReleaseForFlag(
                projectKey = null,
                flagKey = null,
                createReleaseInput = createReleaseInput,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling ReleasesBetaApi#createReleaseForFlag")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling ReleasesBetaApi#createReleaseForFlag")
            e.printStackTrace()
        }
    }
}
